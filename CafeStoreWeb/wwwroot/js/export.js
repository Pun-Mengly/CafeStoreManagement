function ExportEcell() {
    console.log("hello mt blazor with js")
    let a = document.getElementById('table-export');
    console.log(a)
    //let table = document.getElementById("text-header"); // you can use document.getElementById('tableId') as well by providing id to the table tag
    TableToExcel.convert(a[1], { // html code may contain multiple tables so here we are refering to 1st table tag
        name: `Receipt Report.xlsx`, // fileName you could use any name
        sheet: {
            name: 'Receipt', // sheetName
        },
    });
}
