var siteData = {
    isAddOrEdit : false
}

window.onload = function() {
    inventory.init();
    toggleSection();
}

function toggleSection() {
    if(siteData.isAddOrEdit){
        document.getElementById("add-edit-section").style.display = "block";
        document.getElementById("display-grid").style.display = "none";

    }   else {
        document.getElementById("add-edit-section").style.display = "none";
        document.getElementById("display-grid").style.display = "block";

    }

    if(!siteData.isAddOrEdit) {
        loadProducts(inventory.getAllProducts());
    }
}


function showAddEditSection () {
    siteData.isAddOrEdit = true;
    toggleSection();
}

function showGrid() {
    siteData.isAddOrEdit = false;
    toggleSection();
}

function loadProducts(allProducts) {
    var prodTable = "<table><tr><th>Id</th><th>Product Name</th><th>Price</th><th>Category</th><th>Action</th></tr>";
    allProducts.forEach(item => {
        prodTable += "<tr><td>" + item.id + "</td><td>" + item.name + "</td><td>" + item.price + "</td><td>" + item.category +"</td><td><a href='javascript:void(0)' onclick='deleteProduct("+item.id+")'>Delete</a></td></tr>";
    });

    prodTable +="</table>";

    document.getElementById("grid").innerHTML = prodTable;

}

function SaveProduct() {
 var product = new Product();
 product.name = document.getElementById("txtProductId").value;
 product.price = document.getElementById("txtProductPrice").value;
 var category = document.getElementById("ddlCategory");
 product.category = category.options[category.selectedIndex].value;

inventory.addProduct(product);
siteData.isAddOrEdit = false;
toggleSection();

}

function deleteProduct(id) {
    inventory.deleteProductById(id);
    loadProducts(inventory.getAllProducts());
}

function filterData(){
    var searchKey = document.getElementById("txtSearchKey").value;
    var filteredProducts = inventory.filterProducts(searchKey);
    loadProducts(filteredProducts);
}