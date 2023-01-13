let url = "http://localhost:5134/api";
//Get all Categories in table
fetch(url + "/Category")
  .then(res => {
    return res.json();
  })
  .then(data => {
    let tableData = "";
    data.map((values) => {
      tableData += `<tr>
        <th>${values.name}</th>
        <th>${values.limit}</th>
        <th class="actions"><i class="fa-solid fa-pen-to-square" id="cat-edit" style="color: white; cursor: pointer;"></i>
          <i class="fa-solid fa-trash" style="cursor: pointer;"></i></th></tr>`;
});
    document.getElementById("cat-table").innerHTML = tableData;
  }).catch((err) => {
    console.log(err);
  })

// Get all transactions in table
fetch(url + "/Transaction")
  .then(res => {
    return res.json();
  })
  .then(data => {
    let tableData = "";
    data.map((values) => {
      tableData += `<tr>
        <th>${values.expName}</th>
        <th>${values.expDesc}</th>
        <th>${values.category}</th>
        <th>${values.amount}</th>
        <th>${values.date}</th>
<th class="actions"><i class="fa-solid fa-pen-to-square" style="color: white; cursor: pointer;"></i>
          <i class="fa-solid fa-trash" style="cursor: pointer;"></i></th></tr>`;
    });
    document.getElementById("exp-table").innerHTML = tableData;
  }).catch((err) => {
    console.log(err);
  })

  