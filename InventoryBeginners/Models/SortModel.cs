/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Tools
{
    public enum SortOrder { Ascending = 0, Descending = 1 }

    public class SortModel
    {
        private string upIcon = "fa fa-arrow-up";
        private string downIcon = "fa fa-arrow-down";

        public string SortedProperty { get; set; }
        public SortOrder SortedOrder { get; set; }
        private List<SortableColumn> sortableColumns = new List<SortableColumn>();

        //Method checks if the colname exists in the SortModel, if there is no match,
        //a new column is added with ColumnName = colname.  If the isDefaultColumn ==
        //true or there is only 1 column, the column is set as the default SortedProperty.
        public void AddColumn(string colname, bool isDefaultColumn = false)
        {
            SortableColumn tmp = this.sortableColumns.Where(c => c.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
            {
                sortableColumns.Add(new SortableColumn() { ColumnName = colname });
            }

            if (isDefaultColumn == true || sortableColumns.Count == 1)
            {
                SortedProperty = colname;
                SortedOrder = SortOrder.Ascending;
            }
        }

        public SortableColumn GetColumn(string colname)
        {
            SortableColumn tmp = this.sortableColumns.Where(c => c.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
            {
                sortableColumns.Add(new SortableColumn() { ColumnName = colname });
            }
            return tmp;
        }

        public void ApplySort(string sortExpression)
        {
            if (sortExpression == "")
            {
                sortExpression = this.SortedProperty;
            }

            sortExpression = sortExpression.ToLower();

            //Searches the sortable columns in for one that matches the sortExpression, then
            //sets the sort params for that column. Note, the column expression is set with
            //either _desc appended or without, to flip the order on the next sort.
            foreach (SortableColumn sortableColumn in this.sortableColumns)
            {
                sortableColumn.SortIcon = "";
                sortableColumn.SortExpression = sortableColumn.ColumnName;

                if (sortExpression == sortableColumn.ColumnName.ToLower())
                {
                    this.SortedOrder = SortOrder.Ascending;
                    this.SortedProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = downIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName + "_desc";
                }

                if (sortExpression == sortableColumn.ColumnName.ToLower() + "_desc")
                {
                    this.SortedOrder = SortOrder.Descending;
                    this.SortedProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = upIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName;
                }
            }
        }
    }

    public class SortableColumn
    {
        public string ColumnName { get; set; }
        public string SortExpression { get; set; }
        public string SortIcon { get; set; }

    }
}
*/