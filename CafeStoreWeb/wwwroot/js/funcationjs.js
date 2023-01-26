function JsFunction() {
    alert('Hello Blazor Interop with JS')
}
function exportExcel() {
    var inputFrom = new Date();
    var fromDate = formatDate(inputFrom.toDateString());
    let table = document.getElementsByTagName("table"); // you can use document.getElementById('tableId') as well by providing id to the table tag
    TableToExcel.convert(table[1], { // html code may contain multiple tables so here we are refering to 1st table tag
        name: `Test ${fromDate}.xlsx`, // fileName you could use any name
        sheet: {
            name: 'Test', // sheetName
        },
    });
}
//format date
function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();
    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;
    return [year, month, day].join('-');
}