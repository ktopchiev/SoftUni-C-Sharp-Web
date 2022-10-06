namespace ShoppingList.Data
{
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// One product can have many notes
        /// </summary>
        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
