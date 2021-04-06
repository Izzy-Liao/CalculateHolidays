using BusinessDays.Holidays;
using CalculateHolidays.ConfigReader;
using System.Collections.Generic;


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

    }
}
