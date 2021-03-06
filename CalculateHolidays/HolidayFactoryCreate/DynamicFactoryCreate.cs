using BusinessDays.Holidays;
using CalculateHolidays.ConfigReader;


namespace CalculateHolidays.HolidayFactoryCreate
{
    public class DynamicFactoryCreate:IHolidayFactoryCreate
    {
        private readonly IConfig _configReader;

        public DynamicFactoryCreate(IConfig configReader)
        {
            _configReader = configReader;
        }

        public IHoliday CreateHolidayFactory()
        {
            IHoliday holidayFactory = new DynamicHolidayFactory(_configReader.GetHolidayRules(), _configReader.GetHolidayCertainOccurance());
            return holidayFactory;
        }

    }
}
