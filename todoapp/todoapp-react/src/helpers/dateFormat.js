function dateToString(date) {
  /// return date in format Sep 09, 2022
  var month = date.getMonth();
  var day = date.getDate();
  var year = date.getFullYear();
  var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
  return months[month] + " " + day + ", " + year;
}

export { dateToString };
