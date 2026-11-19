namespace CinemaApp.Base
{
    internal static class GridExtensions
    {
        public static void Titulo(this DataGridView grid, string coluna, string titulo)
        {
            if (grid.Columns[coluna] is DataGridViewColumn c)
                c.HeaderText = titulo;
        }

        public static void Preencher(this DataGridView grid, string coluna)
        {
            if (grid.Columns[coluna] is DataGridViewColumn c)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public static void Formato(this DataGridView grid, string coluna, string formato)
        {
            if (grid.Columns[coluna] is DataGridViewColumn c)
                c.DefaultCellStyle.Format = formato;
        }

        public static void Ocultar(this DataGridView grid, string coluna)
        {
            if (grid.Columns[coluna] is DataGridViewColumn c)
                c.Visible = false;
        }
    }
}
