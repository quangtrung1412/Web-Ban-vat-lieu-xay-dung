var tableData = [
    { name: "John Doe", age: 30, city: "New York" },
    { name: "Jane Smith", age: 28, city: "San Francisco" },
    { name: "Bob Johnson", age: 35, city: "Chicago" }
  ];

  var tableContainer = document.getElementById("tableContainer");
  var table = document.createElement("table");
  
  // Add class to the table
  table.classList.add("table");

  // Create the table header
  var thead = document.createElement("thead");
  table.classList.add("thead-dark");
  var headerRow = document.createElement("tr");
  for (var key in tableData[0]) {
    var th = document.createElement("th");
    th.appendChild(document.createTextNode(key));
    headerRow.appendChild(th);
  }
  thead.appendChild(headerRow);
  table.appendChild(thead);

  // Create the table body
  var tbody = document.createElement("tbody");
  for (var i = 0; i < tableData.length; i++) {
    var row = document.createElement("tr");
    for (var key in tableData[i]) {
      var cell = document.createElement("td");
      cell.appendChild(document.createTextNode(tableData[i][key]));
      row.appendChild(cell);
    }
    tbody.appendChild(row);
  }
  table.appendChild(tbody);

  tableContainer.appendChild(table);