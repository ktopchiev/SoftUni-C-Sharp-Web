namespace ShoppingList.Data
{
    public class ProductNote
    {
        /// <summary>
        /// Product note Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///Product note's content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Foreigh key for product id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public Product Product { get; set; }
    }
}
