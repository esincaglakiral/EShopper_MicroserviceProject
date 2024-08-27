﻿namespace EShopper.Discount.Entities
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public int DiscountRate { get; set; }
        public string DiscountCode { get; set; }
        public DateTime ExpiresIn { get; set; }
        public bool IsActive { get; set; }
    }
}
