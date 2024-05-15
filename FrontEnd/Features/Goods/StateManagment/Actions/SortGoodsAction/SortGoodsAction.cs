namespace FrontEnd.Features.Goods.StateManagment.Actions.SortGoodsAction
{
    public class SortGoodsAction
    {
        public int CategoryId { get; }
        public string FieldName { get; }
        public bool Ascending { get; }
        public SortGoodsAction(int categoryId, string fieldName, bool ascending)
        {
            CategoryId = categoryId;
            FieldName = fieldName;
            Ascending = ascending;
        }
    }
}
