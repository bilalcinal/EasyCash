using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Abstract;
using EasyCash.Entities.Concrete;

namespace EasyCash.Business.Concrete;

public class CustomerAcccountManager : ICustomerAccountService
{
    private readonly ICustomerAccountDal _customerAccountDal;

    public CustomerAcccountManager(ICustomerAccountDal customerAccountDal)
    {
        _customerAccountDal = customerAccountDal;
    }

    public void TDelete(CustomerAccount t)
    {
        _customerAccountDal.Delete(t);
    }

    public CustomerAccount TGetById(int id)
    {
       return _customerAccountDal.GetById(id);
    }

    public List<CustomerAccount> TGetList()
    {
        return _customerAccountDal.GetList();
    }

    public void TInsert(CustomerAccount t)
    {
        _customerAccountDal.Insert(t);
    }

    public void TUpdate(CustomerAccount t)
    {
       _customerAccountDal.Update(t);
    }
}
