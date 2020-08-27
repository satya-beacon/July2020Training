//This is for Product model
function Product(id, name, price, category){
    this.id = id;
    this.name = name;
    this.price = price;
    this.category = category;

}

//Inventory store - namespace
var inventory = {}
inventory.appName = 'Product Management App';
inventory.appVersion = "1.0.0.0";
inventory.products = [];

//This is for initializing the data
inventory.init = function() {
    if(localStorage.getItem('prodData')){
        this.products = JSON.parse(localStorage.getItem('prodData'));
    }else{
        this.products = [];
        this.products.push(new Product(this.products.length +1, 'IPad', 500, 'Tablet'));  
        this.products.push(new Product(this.products.length +1, 'Iphone', 1000, 'Mobile'));
        localStorage.setItem('prodData', JSON.stringify(this.products));
    }
   
}

//Adding a new product
inventory.addProduct = function(product) {
    product.id = this.products.length +1;
    this.products.push(product);
    localStorage.setItem('prodData', JSON.stringify(this.products));
}

//GEt the product by Id
inventory.getProductById = function(id) {
    var returnProduct = null;
    for(var idx = 0; idx < this.products.length; idx ++) {
        if(this.products[idx].id === id) {
            returnProduct = this.products[idx];
            break;
        }
    }

    return returnProduct;
}

inventory.filterProducts = function(searchKey) {
    if(searchKey === null || searchKey === undefined || searchKey === ''){
        return this.products;
    }

    var results = [];
    for(var idx = 0; idx < this.products.length; idx ++) {
        if(this.products[idx].name.toLowerCase().indexOf(searchKey.toLowerCase()) !== -1) {
           results.push(this.products[idx]);
        }
    }

    return results;
}

inventory.getAllProducts = function() {
    return this.products;
}

inventory.deleteProductById = function(id){
    for(var idx = 0; idx < this.products.length; idx ++){
        if(this.products[idx].id === id) {
           this.products.splice(idx, 1);
           break;
        }
    }

    localStorage.setItem('prodData', JSON.stringify(this.products));

}

//update the product
inventory.updateProduct = function(product) {
    //write the logic
}