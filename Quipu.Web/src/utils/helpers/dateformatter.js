export function formatMMDD(input) {
  var newDate = new Date(input);
  return newDate.getMonth() + "/" + newDate.getDate();
}

export function formatMonthNameDD(input) {
  var newDate = new Date(input);
  const month = newDate.toLocaleString("default", { month: "short" });
  return month + " " + newDate.getDate();
}

export function formatDateToSQLString(date) {
  return date.toISOString().slice(0, 19).replace("T", " ");
}
