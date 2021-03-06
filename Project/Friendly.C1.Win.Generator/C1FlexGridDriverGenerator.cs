﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Friendly.C1.Win.Generator
{
    [CaptureCodeGenerator("Friendly.C1.Win.C1FlexGridDriver")]
    public class C1FlexGridDriverGenerator : CaptureCodeGeneratorBase
    {
        dynamic _grid;
        object[] _tokens;
        List<Action> _removes = new List<Action>();

        protected override void Attach()
        {
            _grid = ControlObject;
            _removes.Add(EventAdapter.Add(ControlObject, "SelChange", SelChange));
            _removes.Add(EventAdapter.Add(ControlObject, "AfterEdit", AfterEdit));
            _removes.Add(EventAdapter.Add(ControlObject, "ValidateEdit", ValidateEdit));
        }

        protected override void Detach() => _removes.ForEach(e => e());

        void SelChange(object sender, dynamic e)
        {
            if (!_grid.Focused) return;
            AddSentence(new TokenName(), ".EmulateSelect(", _grid.Row, ", ", _grid.Col, ");");
        }

        void ValidateEdit(object sender, dynamic e)
        {
            if (_grid.Editor is ComboBox combo)
            {
                _tokens = new object[]
                {
                    new TokenName(),
                    ".EmulateEditCombo(",
                    combo.SelectedIndex,
                     ");"
                };
            }
            else if (_grid.Editor is TextBox text)
            {
                _tokens = new object[]
                {
                    new TokenName(),
                    ".EmulateEditText(",
                    GenerateUtility.AdjustText(text.Text),
                     ");"
                };
            }
            else if (_grid.Editor == null)
            {
                _tokens = new object[]
                {
                    new TokenName(),
                    ".EmulateEditCheck(",
                    e.Checkbox.ToString() == "Checked" ? "true" : "false",
                     ");"
                };
            }
            else
            {
                _tokens = null;
            }
        }

        void AfterEdit(object sender, dynamic e)
        {
            if (_tokens == null) return;
            AddSentence(_tokens);
            _tokens = null;
        }

        public override void Optimize(List<Sentence> code)
        {
            GenerateUtility.RemoveDuplicationFunction(this, code, "EmulateSelect");
        }

        public override bool ConvertChildClientPoint(ref Point clientPoint, out string childUIObject)
        {
            childUIObject = string.Empty;
            var info = _grid.HitTest(clientPoint);
            if (info.Row < 0 || _grid.Rows.Count <= info.Row) return false;
            if (info.Column < 0 || _grid.Cols.Count <= info.Column) return false;

            childUIObject = $".GetCell({info.Row}, {info.Column})";

            var rc = _grid.GetCellRect(info.Row, info.Column);
            clientPoint = new Point(clientPoint.X - rc.X, clientPoint.Y - rc.Y);
            return true;
        }
    }
}
