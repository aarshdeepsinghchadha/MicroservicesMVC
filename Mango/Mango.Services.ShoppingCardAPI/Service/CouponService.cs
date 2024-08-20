using Mango.Services.ShoppingCardAPI.Models.Dto;
using Mango.Services.ShoppingCardAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCardAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var respone = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");
            var apiContent = await respone.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.Result));
            }
            return new CouponDto();
        }
    }
}
