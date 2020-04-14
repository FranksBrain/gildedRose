namespace csharpcore
{
    public class AgedBrieRule : IRule
    {
        public void Eval(Item item)
        {
            if(item.Name == ItemName.AGED_BRIE){
                item.Quality += 1;
            }
        }
    }
}
