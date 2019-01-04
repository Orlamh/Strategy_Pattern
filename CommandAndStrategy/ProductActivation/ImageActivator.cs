using System;

namespace CommandPattern
{

    public partial class ActivateProductCommand
    {
        public class ImageActivator : IActivator
        {
            private ProductType ProductType => ProductType.Image;
            public void Activate(Context context)
            {
                Console.WriteLine("The ImagePack is activated");
            }

            public bool IsMatch(ProductType purchasedType)
            {
                return purchasedType == ProductType;
            }
        }
    }
}