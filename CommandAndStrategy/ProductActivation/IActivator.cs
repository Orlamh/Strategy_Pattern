namespace CommandPattern
{
    public interface IActivator
    {
        void Activate(Context context);
        bool IsMatch(ProductType purchasedType);
    }
}