using BusinessDays.Holidays;
using CalculateHolidays.ConfigReader;


namespace CalculateHolidays.HolidayFactoryCreate
{
    public class FixedFactoryCreate:IHolidayFactoryCreate
    {
        private readonly IConfig _configReader;

        public FixedFactoryCreate(IConfig configReader)
        {
            _configReader = configReader;
        }

        public IHoliday CreateHolidayFactory()
        {
            string[] holidayStrings = _configReader.GetFixedHoliday();
            IHoliday holidayFactory = new FixedHolidayFactory(holidayStrings);
            return holidayFactory;
        }

        public IHoliday GetFactory(List<HolidayRule> holidayRules, List<HolidayCertainOccurance> certainHolidayOccurances)
        {
            IConfig config = new ConfigDefaultReader(_config);
            IHoliday holidayFactory = new DynamicHolidayFactory(config.GetHolidayRules(), config.GetHolidayCertainOccurance());
            return holidayFactory;
        }
    }
}
