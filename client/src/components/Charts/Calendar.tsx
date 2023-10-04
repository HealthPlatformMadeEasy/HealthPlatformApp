import { useState } from "react";
import { CalendarProps, IDay } from "../../Model";

const DAYS = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"];
const MONTHS = [
  "January",
  "February",
  "March",
  "April",
  "May",
  "June",
  "July",
  "August",
  "September",
  "October",
  "November",
  "December",
];

export function Calendar({ priceData, goal, unit }: CalendarProps) {
  const [currentMonth, setCurrentMonth] = useState(new Date().getMonth());
  const [currentYear, setCurrentYear] = useState(new Date().getFullYear());
  const monthDates: Array<IDay> = [];

  const daysInMonth = 32 - new Date(currentYear, currentMonth, 32).getDate();

  for (let i = 1; i <= daysInMonth; i++) {
    const date = new Date(currentYear, currentMonth, i);
    const priceForDate = priceData?.find(
      (p) => p.createdAt.toDateString() === date.toDateString(),
    );
    monthDates.push({ date, value: priceForDate ? priceForDate.value : null });
  }

  const firstDayIndex = monthDates[0].date.getDay() || 7;

  for (let i = 1; i < firstDayIndex; i++) {
    monthDates.unshift({
      date: new Date(currentYear, currentMonth, -i),
      value: null,
    });
  }

  while (monthDates.length % 7 !== 0) {
    const lastDay = monthDates[monthDates.length - 1].date;
    monthDates.push({
      date: new Date(
        lastDay.getFullYear(),
        lastDay.getMonth(),
        lastDay.getDate() + 1,
      ),
      value: null,
    });
  }

  return (
    <div>
      <div className="mb-2 flex items-center justify-between gap-2">
        <div className="grid w-3/4 items-center justify-center rounded-xl border-2 border-pine_green-600 bg-pine_green-900 font-playfair text-lg lg:px-4 lg:pb-4 lg:pt-1 lg:text-5xl">
          <h2 className="text-center">{`${MONTHS[currentMonth]} ${currentYear}`}</h2>
        </div>
        <div className="flex w-1/3 items-center justify-center space-x-4 rounded-xl border-2 border-pine_green-600 bg-pine_green-900 p-1 lg:p-4">
          <button
            className="w-1/2 rounded-xl bg-marian_blue p-1 text-center text-white transition duration-300 ease-in-out hover:scale-110 lg:px-4 lg:py-1"
            onClick={() => {
              if (currentMonth === 0) {
                setCurrentMonth(11);
                setCurrentYear(currentYear - 1);
              } else {
                setCurrentMonth(currentMonth - 1);
              }
            }}
          >
            Prev
          </button>
          <button
            className="w-1/2 rounded-xl bg-marian_blue p-1 text-white transition duration-300 ease-in-out hover:scale-110 lg:px-4 lg:py-1"
            onClick={() => {
              if (currentMonth === 11) {
                setCurrentMonth(0);
                setCurrentYear(currentYear + 1);
              } else {
                setCurrentMonth(currentMonth + 1);
              }
            }}
          >
            Next
          </button>
        </div>
      </div>
      <div className="grid grid-cols-7 gap-1">
        {DAYS.map((day, index) => (
          <div
            key={index}
            className="rounded-xl border-2 border-pine_green-600 bg-pine_green-900 text-center lg:px-2 lg:py-1"
          >
            {day}
          </div>
        ))}
        {monthDates.map((day, index) => (
          <div
            key={index}
            className={
              day.value
                ? day.value <= goal
                  ? "flex flex-col rounded border-2 border-pine_green-600 bg-marian_blue-700 p-2 lg:flex-row"
                  : day.value <= goal + 10
                  ? "flex flex-col rounded border-2 border-pine_green-600 bg-hunyadi_yellow-700 p-2 lg:flex-row"
                  : "flex flex-col rounded border-2 border-pine_green-600 bg-madder-700 p-2 lg:flex-row"
                : "flex flex-col rounded border-2 border-pine_green-600 bg-pine_green-900 p-2 lg:flex-row"
            }
          >
            <div className="text-sm font-light text-pine_green-200">
              {day.date.getDate()}
            </div>
            {day.value && (
              <div className="text-center">
                {day.value.toFixed(2)}
                <span className="text-xs font-light">{unit}</span>
              </div>
            )}
          </div>
        ))}
      </div>
    </div>
  );
}

export default Calendar;
