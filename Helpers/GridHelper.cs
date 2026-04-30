using System.Collections.Generic;
using System.Windows.Forms;

namespace EquipmentAccounting.Helpers
{
    public static class GridHelper
    {
        public static void ConfigureBase(DataGridView grid)
        {
            grid.AutoGenerateColumns = true;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
        }

        public static void ApplyHeaders(
            DataGridView grid,
            Dictionary<string, string> headers,
            params string[] hiddenColumns)
        {
            foreach (var columnName in hiddenColumns)
            {
                if (grid.Columns.Contains(columnName))
                    grid.Columns[columnName].Visible = false;
            }

            foreach (var kv in headers)
            {
                if (grid.Columns.Contains(kv.Key))
                    grid.Columns[kv.Key].HeaderText = kv.Value;
            }
        }

        public static void AddActionButtons(
            DataGridView grid,
            string editColumnName,
            string deleteColumnName)
        {
            if (!grid.Columns.Contains(editColumnName))
            {
                grid.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = editColumnName,
                    HeaderText = "Редактировать",
                    Text = "Ред.",
                    UseColumnTextForButtonValue = true,
                    Width = 75
                });
            }

            if (!grid.Columns.Contains(deleteColumnName))
            {
                grid.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = deleteColumnName,
                    HeaderText = "Удалить",
                    Text = "Удал.",
                    UseColumnTextForButtonValue = true,
                    Width = 75
                });
            }
        }
    }
}