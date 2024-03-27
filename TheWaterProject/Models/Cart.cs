namespace TheWaterProject.Models
{
    public class Cart
    {
        //This gives us an ability to store a list of lines, which line consists of the three pieces of infomration below.
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem(Project proj, int quantity)
        {
            //Search the line list for the item being added
            CartLine? line = Lines
                .Where(x => x.Project.projectId == proj.projectId)
                .FirstOrDefault();

            //Has this item already been added to our cart? If it does not find an item, add a new line
            if (line == null) 
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = quantity
                });
            }
            //Otherwise, just add 1 to the quantity to the existing item...
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Project proj) => Lines.RemoveAll(x => x.Project.projectId == proj.projectId);

        public void Clear() => Lines.Clear();

        //The $25 is a $25 donation that is hardcoded. We could have the user do something later...this just makes it easier for now.
        public decimal CalculateTotal() => Lines.Sum(x => 25 * x.Quantity);

        public class CartLine
        {
            public int CartLineId { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }
    }
}
