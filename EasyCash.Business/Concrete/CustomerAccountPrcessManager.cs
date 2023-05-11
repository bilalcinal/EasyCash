using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Abstract;
using EasyCash.Entities.Concrete;

namespace EasyCash.Business.Concrete;

public class CustomerAccountPrcessManager : ICustomerAccountProcessService
{

    private readonly ICustomerAccountProcessDal _customerAccountProcess;

    public CustomerAccountPrcessManager(ICustomerAccountProcessDal customerAccountProcess)
    {
        _customerAccountProcess = customerAccountProcess;
    }

    public void TDelete(CustomerAccountProcess t)
    {
        _customerAccountProcess.Delete(t);
    }

    public CustomerAccountProcess TGetById(int id)
    {
        return _customerAccountProcess.GetById(id);
    }

    public List<CustomerAccountProcess> TGetList()
    {
        return _customerAccountProcess.GetList();
    }

    public void TInsert(CustomerAccountProcess t)
    {
        _customerAccountProcess.Insert(t);
    }

    public void TUpdate(CustomerAccountProcess t)
    {
        _customerAccountProcess.Update(t);
    }
}
