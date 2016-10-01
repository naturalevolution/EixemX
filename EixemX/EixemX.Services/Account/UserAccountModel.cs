using System;
using EixemX.Services.Base;

namespace EixemX.Services.Account
{
    public class UserAccountModel : BaseModel
    {
        public UserAccountModel()
        {
            Borrow = new BorrowAccountModel();
            Loan = new LoanAccountModel();
            Interest = new InterestAccountModel();
            User = new UserDetailModel();
        }

        public UserDetailModel User { get; set; }
        public BorrowAccountModel Borrow { get; set; }
        public LoanAccountModel Loan { get; set; }
        public InterestAccountModel Interest { get; set; }
    }

    public class UserDetailModel : BaseModel
    {
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateInscription { get; set; }
        public UserAddressModel Address { get; set; }
        public UserBankModel Bank { get; set; }
        public UserFinanceModel Finance { get; set; }

        public string DisplayFullname()
        {
            return string.Format("{0} {1}", Firstname, Lastname).ToUpper();
        }

        public void Update(UserDetailModel model)
        {
            Lastname = model.Lastname;
            Email = model.Email;
            Firstname = model.Firstname;
            DateInscription = model.DateInscription;
            DateBirth = model.DateBirth;
            Address = model.Address;
            Bank = model.Bank;
            Finance = model.Finance;
        }
    }

    public class UserFinanceModel : BaseModel
    {
        public double Amount { get; set; }

        public string DisplayAmount()
        {
            return DisplayDouble(Amount);
        }
    }

    public class UserBankModel : BaseModel
    {
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiredDate { get; set; }
        public string Iban { get; set; }
         
        public string DisplayDateExpiration()
        {
            return CardExpiredDate.ToString("dd/mm");
        }
    }

    public class UserAddressModel : BaseModel
    {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string DisplayCity()
        {
            return string.Format("{0} {1}", PostalCode, City).ToUpper();
        }

        public string DisplayCountry()
        {
            return Country.ToUpper();
        }
    }

    public class InterestAccountModel : BaseModel
    {
        public double Amount { get; set; }

        public void AddInterest(double value)
        {
            Amount = value;
        }
        public string DisplayAmount()
        {
            return DisplayDouble(Amount);
        }
    }

    public class LoanAccountModel : BaseModel
    {
        public double Amount { get; set; }

        public void AddLoan(double value)
        {
            Amount = value;
        }
        public string DisplayAmount()
        {
            return DisplayDouble(Amount);
        }
    }

    public class BorrowAccountModel : BaseModel
    {
        public DateTime DateAvailable { get; set; }
        public DateTime DateNextRefound { get; set; }
        public double AmountAvailable { get; set; }
        public double AmountRemainingCapacity { get; set; }

        public void AddBorrow(double amountAvailable, double amountRemainingCapacity, DateTime availableTo)
        {
            AmountAvailable = amountAvailable;
            AmountRemainingCapacity = amountRemainingCapacity;
            DateAvailable = availableTo;
        }

        public string ToDateAvailable()
        {
            return DateAvailable.ToString("d");
        }

        public string DisplayAmountAvailable()
        {
            return DisplayDouble(AmountAvailable);
        }

        public string DisplayAmountRemainingCapacity()
        {
            return DisplayDouble(AmountRemainingCapacity);
        }

        public string ToDateNextRefound()
        {
            return DateNextRefound.ToString("d");
        }
    }
}