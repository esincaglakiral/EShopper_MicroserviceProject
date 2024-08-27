namespace EShopper.Discount.Dtos
{
    public class CreateCouponDto
    {
        public int DiscountRate { get; set; }
        public string DiscountCode { get; set; }
        public DateTime ExpiresIn { get; set; }
        public bool IsActive { get; set; }
    }
}
