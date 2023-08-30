function getDaysInMonth(month: number, year: number) {
  const date = new Date(year, month, 1);
  const days = [];
  while (date.getMonth() === month) {
    days.push(new Date(date));
    date.setDate(date.getDate() + 1);
  }
  return days;
}

const adjustDayOfWeek = (dayOfWeek: number) => {
  return (dayOfWeek + 6) % 7;
};

// const date = new Date(); // your given date
// const year = date.getFullYear();
// const month = date.getMonth();
// const firstDayOfMonth = new Date(year, month, 1);

export function Calendar() {
  const date = new Date("september 1, 2023, 00:00:01");

  const days = getDaysInMonth(date.getMonth(), date.getFullYear());
  const firstDayOfWeek = adjustDayOfWeek(date.getDay());
  const dayNames = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"];

  return (
    <div>
      <div className="grid w-[550px] grid-cols-7 place-items-center gap-2 rounded-xl border-2 border-pine_green-600 bg-pine_green-800 p-2">
        {dayNames.map((dayName) => (
          <div
            key={dayName}
            className="w-full rounded-xl border border-pine_green-600 bg-pine_green-900 text-center"
          >
            {dayName}
          </div>
        ))}
        {Array(firstDayOfWeek)
          .fill(null)
          .map((_, idx) => (
            <div key={`empty-${idx}`} />
          ))}
        {days.map((day) => (
          <div
            key={day.toString()}
            className="rounded-xl border border-pine_green-600 bg-pine_green-900 p-2"
          >
            <div>{day.getDate()}</div>
            <div className="p-2">Algo</div>
          </div>
        ))}
      </div>
    </div>
  );
}
