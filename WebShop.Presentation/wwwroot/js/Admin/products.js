var app = new Vue({
    el: '#app',
    data:  {
        editing: false,
        loading: false,
        objectIndex: 0,
        productModel: {
            id: 0,
            name: "JSTest-Name",
            description: "JSTest-description",
            price: "1000"
        },
        products: []        
    },
    mounted() {
        this.getProducts()
    },
    methods: {
        getProduct(id) {
            this.loading = true;
            axios.get('/products/' + id)
                .then(result => {
                    console.log(result);
                    var product = result.data
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        price: product.price,
                    }
                })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getProducts() {
            this.loading = true;
            axios.get('/products')
                .then(result => {
                    console.log(result);
                    this.products = result.data
                })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        createProduct() {
            axios.post('/products', this.productModel)
                .then(result => {
                    console.log(result.data)
                    this.products.push(result.data);
                })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        updateProduct() {
            axios.put('/products', this.productModel)
                .then(result => {
                    console.log(result.data)
                    this.products.splice(this.objectIndex, 1, result.data);
                })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        deleteProduct(id, index) {
            this.loading = true;
            axios.delete('/products/' + id)
                .then(result => {
                    console.log(result);
                    this.products.splice(index, 1)
                })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        newProduct() {
            this.editing = true;
            this.productModel.id = 0;
        },
        editProduct(id, index) {
            this.objectIndex = index;
            this.getProduct(id);
            this.editing = true;
        },
        cancel() {
            this.editing = false;
        }
    },
    computed: {
    }
});