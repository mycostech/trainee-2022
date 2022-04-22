function dateToString(date) {
  /// return date in format Sep 09, 2022
  var month = date.getMonth();
  var day = date.getDate();
  var year = date.getFullYear();
  var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
  return months[month] + " " + day + ", " + year;
}

function dateToTimeString(date) {
  // return date in format 12:00 AM
  var hours = date.getHours();
  var minutes = date.getMinutes();
  var ampm = hours >= 12 ? "PM" : "AM";
  hours = hours % 12;
  hours = hours ? hours : 12; // the hour '0' should be '12'
  minutes = minutes < 10 ? "0" + minutes : minutes;
  var strTime = hours + ":" + minutes + " " + ampm;
  return strTime;
}

function dateToDateTimeString(date) {
  var month = date.getMonth();
  var day = date.getDate();
  var year = date.getFullYear();
  var hours = date.getHours();
  var minutes = date.getMinutes();
  var seconds = date.getSeconds();
  var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
  return months[month] + " " + day + ", " + year + " " + hours + ":" + minutes + ":" + seconds;
}

export { dateToString, dateToTimeString, dateToDateTimeString };
