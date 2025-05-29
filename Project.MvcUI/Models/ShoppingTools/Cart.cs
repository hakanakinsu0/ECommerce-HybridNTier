using Newtonsoft.Json;

namespace Project.MvcUI.Models.ShoppingTools
{
    //Sepet
    [Serializable]
    public class Cart
    {
        [JsonProperty("_myCart")]
        Dictionary<int, CartItem> _myCart;

        [JsonProperty("GetCartItems")]
        public List<CartItem> GetCartItems
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void IncreaseCartItem(int id)
        {
            _myCart[id].Amount++;
        }

        public void AddToCart(CartItem item)
        {
            if (_myCart.ContainsKey(item.Id))
            {
                IncreaseCartItem(item.Id);
                return;
            }
            _myCart.Add(item.Id, item);
        }

        public void Decrease(int id)
        {
            _myCart[id].Amount--;
            if (_myCart[id].Amount == 0) _myCart.Remove(id);
        }

        public void RemoveFromCart(int id)
        {
            _myCart.Remove(id);
        }

        [JsonProperty("TotalPrice")]
        public decimal TotalPrice
        {
            get
            {
                return _myCart.Values.Sum(x => x.SubTotal);
            }
        }
    }
}
