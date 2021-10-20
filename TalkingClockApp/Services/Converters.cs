using System;
using TalkingClockApp.Reference;

namespace TalkingClockApp.Services
{
    public class Converters
    {
        /// <summary>
        /// Takes a DateTime and returns whether it is morning or afternoon
        /// </summary>
        public static string MorningOrAfternoon(DateTime dateTime)
        {
            if (dateTime.Hour > 11)
            {
                return "in the afternoon";
            }
            else
            {
                return "in the morning";
            }
        }

        /// <summary>
        /// Takes a DateTime and returns whether it is "past" the hour or "to" the hour
        /// </summary>
        public static string PastOrTo(DateTime dateTime)
        {
            if (dateTime.Minute > 29)
            {
                return "to";
            }
            else
            {
                return "past";
            }
        }

        /// <summary>
        /// Takes a DateTime and returns a string of the time in human readable format e.g. "Hello - the time is nine to two in the afternoon"
        /// </summary>
        public static string NumberMinutesToText(DateTime currentDateTime)
        {
            var amOrPm = Converters.MorningOrAfternoon(currentDateTime);
            var pastOrTo = Converters.PastOrTo(currentDateTime);
            var currentHour = Int32.Parse(currentDateTime.ToString("%h"));
            //On the hour - the format is "{hour} o'clock"
            if (currentDateTime.Minute == 0)
            {
                return ($"{Environment.NewLine}Hello - the time is {ReferenceData.unitsMap[currentHour]} o'clock {amOrPm}");
            }
            //On the quarter past the hour the format is "Quarter past {hour}"
            else if (currentDateTime.Minute == 15)
            {
                return ($"{Environment.NewLine}Hello - the time is quarter past {ReferenceData.unitsMap[currentHour]} {amOrPm}");
            }
            //On the half hour the format is "Half past {hour}"
            else if (currentDateTime.Minute == 30)
            {
                return ($"{Environment.NewLine}Hello - the time is half past {ReferenceData.unitsMap[currentHour]} {amOrPm}");
            }
            //On the quarter to the hour the format is "Quarter to {hour+1}"
            else if (currentDateTime.Minute == 45)
            {
                return ($"{Environment.NewLine}Hello - the time is quarter to {ReferenceData.unitsMap[currentHour+1]} {amOrPm}");
            }
            //For 1 -29 mins it is current mins past {hour}
            else if (currentDateTime.Minute > 0 & currentDateTime.Minute < 30)
            {
                return ($"{Environment.NewLine}Hello - the time is {ReferenceData.unitsMap[currentDateTime.Minute]} {pastOrTo} {ReferenceData.unitsMap[currentHour]} {amOrPm}");
            }
            //For 31-59 mins it is 60 - current mins to {hour+1}
            else
            {
                return ($"{Environment.NewLine}Hello - the time is {ReferenceData.unitsMap[60-currentDateTime.Minute]} {pastOrTo} {ReferenceData.unitsMap[currentHour+1]} {amOrPm}");
            }
        }

        /// <summary>
        /// Converts a string entered by user in this format "15:00" into human readable format
        /// </summary>
        public static string TextNumbersToText(string[] args)
        {
            //Try and convert the user string into a DateTime
            try
            {
                return NumberMinutesToText(DateTime.ParseExact(args[0], "HH:mm", System.Globalization.CultureInfo.InvariantCulture));
            }
            catch
            {
                return "Unable to process request. Please enter time in this format 15:00";
            }
        }
    }
}
