using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessDays.Holidays;
using BusinessDays.BusinessDaysCalculation;
using System;
using System.Collections.Generic;

namespace BusinessCalculationUnitTest
{
    [TestClass]
    public class BusinessDaysCalculationUnitTest
    {
        [TestMethod]
        public void TestGetWorkDays()
        {
            IGetWorkDays workDaysCalculate = new WorkDaysCalculate();
            DateTime start = new DateTime(2021, 3, 1);
            DateTime end = new DateTime(2021, 3, 31);
            int workDays = workDaysCalculate.GetWorkDays(start, end);
            Assert.AreEqual(workDays, 21);
        }

        [TestMethod]
        public void TestGetWorkDaysInvalidInput()
        {
            IGetWorkDays workDaysCalculate = new WorkDaysCalculate();
            DateTime start = new DateTime(2021, 3, 31);
            DateTime end = new DateTime(2021, 3, 1);
            int workDays = workDaysCalculate.GetWorkDays(start, end);
            Assert.AreEqual(workDays, -1);
        }

        [TestMethod]
        public void TestGetWorkDaysExtremeCase()
        {
            IGetWorkDays workDaysCalculate = new WorkDaysCalculate();
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MaxValue;
            int workDays = workDaysCalculate.GetWorkDays(start, end);
            Assert.AreEqual(workDays, 2608613);
        }

        [TestMethod]
        public void TestGetBusinessDaysWithNSWHoliday()
        {
            IHoliday holidayFactory = new HolidaysFactory();
            IGetBusinessDays getBusinessDays = new BusinessDaysCalculate(holidayFactory);
            DateTime start = new DateTime(2021, 1, 1);
            DateTime end = new DateTime(2021, 12, 31);
            int workDays = getBusinessDays.GetBusinessDaysInBetween(start, end);
            Assert.AreEqual(workDays, 254);
        }

        [TestMethod]
        public void TestGetBusinessDaysWithNSWHolidayInvalidInput()
        {
            IHoliday holidayFactory = new HolidaysFactory();
            IGetBusinessDays getBusinessDays = new BusinessDaysCalculate(holidayFactory);
            DateTime start = new DateTime(2021, 3, 1);
            DateTime end = new DateTime(2021, 1, 31);
            int workDays = getBusinessDays.GetBusinessDaysInBetween(start, end);
            Assert.AreEqual(workDays, -1);
        }

        [TestMethod]
        public void TestGetBusinessDaysWithFixedHoliday()
        {
            String[] holidayStrings = new String[] {"26/01/2021","02/04/2021","01/06/2021","25/12/2021",
                "26/01/2022","02/04/2022","01/06/2022","25/12/2022",
                "26/01/2023","02/04/2023","01/06/2023","25/12/2023",
                "26/01/2024","02/04/2024","01/06/2024","25/12/2024",
                "26/01/2025","02/04/2025","01/06/2025","25/12/2025",
                "26/01/2026","02/04/2026","01/06/2026","25/12/2026",
                "26/01/2027","02/04/2027","01/06/2027","25/12/2027",
                "26/01/2028","02/04/2028","01/06/2028","25/12/2028",
                "26/01/2029","02/04/2029","01/06/2029","25/12/2029"};

            IHoliday holidayFactory = new FixedHolidayFactory(holidayStrings);
            IGetBusinessDays getBusinessDays = new BusinessDaysCalculate(holidayFactory);
            DateTime start = new DateTime(2021, 1, 1);
            DateTime end = new DateTime(2021, 12, 31);
            int workDays = getBusinessDays.GetBusinessDaysInBetween(start, end);
            Assert.AreEqual(workDays, 257);
        }

        [TestMethod]
        public void TestGetBusinessDaysWithFixedHolidayInvalidInput()
        {
            String[] holidayStrings = new String[] {"26/01/2021","02/04/2021","01/06/2021","25/12/2021",
                "26/01/2022","02/04/2022","01/06/2022","25/12/2022",
                "26/01/2023","02/04/2023","01/06/2023","25/12/2023",
                "26/01/2024","02/04/2024","01/06/2024","25/12/2024",
                "26/01/2025","02/04/2025","01/06/2025","25/12/2025",
                "26/01/2026","02/04/2026","01/06/2026","25/12/2026",
                "26/01/2027","02/04/2027","01/06/2027","25/12/2027",
                "26/01/2028","02/04/2028","01/06/2028","25/12/2028",
                "26/01/2029","02/04/2029","01/06/2029","25/12/2029"};

            IHoliday holidayFactory = new FixedHolidayFactory(holidayStrings);
            IGetBusinessDays getBusinessDays = new BusinessDaysCalculate(holidayFactory);
            DateTime start = new DateTime(2021, 3, 1);
            DateTime end = new DateTime(2021, 1, 31);
            int workDays = getBusinessDays.GetBusinessDaysInBetween(start, end);
            Assert.AreEqual(workDays, -1);
        }


        [TestMethod]
        public void TestGetBusinessDaysWithDynamicHoliday()
        {
            List<HolidayRule> holidayRules = new List<HolidayRule>
            {
                new HolidayRule { Day = 1, Month = 1, Movable = true, Name = "New Year" },
                new HolidayRule { Day = 26, Month = 1, Movable = false, Name = "Australia Day" },
                new HolidayRule { Day = 25, Month = 12, Movable = false, Name = "Christmas Day" }
            };
            List<HolidayCertainOccurance> certainOccuranceRules = new List<HolidayCertainOccurance>
            {
                new HolidayCertainOccurance { Month = 4, No = 2, DayOfWeek = DayOfWeek.Sunday, Name = "Easter Sunday" },
                new HolidayCertainOccurance { Month = 4, No = 3, DayOfWeek = DayOfWeek.Monday, Name = "Easter Monday" },
                new HolidayCertainOccurance { Month = 9, No = 1, DayOfWeek = DayOfWeek.Sunday, Name = "Father's Day" }
            };
            IHoliday holidayFactory = new DynamicHolidayFactory(holidayRules, certainOccuranceRules);
            IGetBusinessDays getBusinessDays = new BusinessDaysCalculate(holidayFactory);
            DateTime start = new DateTime(2021, 1, 1);
            DateTime end = new DateTime(2021, 12, 31);
            int workDays = getBusinessDays.GetBusinessDaysInBetween(start, end);
            Assert.AreEqual(workDays, 258);
        }

        [TestMethod]
        public void TestGetBusinessDaysWithDynamicHolidayInvalidInput()
        {
            List<HolidayRule> holidayRules = new List<HolidayRule>
            {
                new HolidayRule { Day = 1, Month = 1, Movable = true, Name = "New Year" },
                new HolidayRule { Day = 26, Month = 1, Movable = false, Name = "Australia Day" },
                new HolidayRule { Day = 25, Month = 12, Movable = false, Name = "Christmas Day" }
            };
            List<HolidayCertainOccurance> certainOccuranceRules = new List<HolidayCertainOccurance>
            {
                new HolidayCertainOccurance { Month = 4, No = 2, DayOfWeek = DayOfWeek.Sunday, Name = "Easter Sunday" },
                new HolidayCertainOccurance { Month = 4, No = 3, DayOfWeek = DayOfWeek.Monday, Name = "Easter Monday" },
                new HolidayCertainOccurance { Month = 9, No = 1, DayOfWeek = DayOfWeek.Sunday, Name = "Father's Day" }
            };
            IHoliday holidayFactory = new DynamicHolidayFactory(holidayRules, certainOccuranceRules);
            IGetBusinessDays getBusinessDays = new BusinessDaysCalculate(holidayFactory);
            DateTime start = new DateTime(2021, 3, 1);
            DateTime end = new DateTime(2021, 1, 31);
            int workDays = getBusinessDays.GetBusinessDaysInBetween(start, end);
            Assert.AreEqual(workDays, -1);
        }
    }
}
