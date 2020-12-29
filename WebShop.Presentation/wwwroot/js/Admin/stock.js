var app = new Vue({
    el: '#app',
    data: {
        products: [],
        selectedProduct: null,
        newStock: {
            productId: 0,
            description: "Standard Edition",
            quantity: 1
        }
    },
    mounted() {
        this.getStock();
    },
    methods: {
        getStock() {
            this.loading = true;
            axios.get('/stocks')
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
        deleteStock(id, index) {
            this.loading = true;
            axios.delete('/stocks/' + id)
                .then(result => {
                    console.log(result);
                    this.selectedProduct.stock.splice(index, 1)
                })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateStock() {
            this.loading = true;
            axios.put('/stocks', {
                stock: this.selectedProduct.stock.map(x => {
                    return {
                        id: x.id,
                        description: x.description,
                        quantity: x.quantity,
                        productId: this.selectedProduct.id
                    };
                })})
                .then(result => {
                    console.log(result);
                    this.selectedProduct.stock.splice(index, 1)
                })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        addStock() {
            this.loading = true;
            axios.post('/stocks', this.newStock)
                .then(result => {
                    console.log(result);
                    this.selectedProduct.stock.push(result.data)
                })
                .catch(error => {
                    console.log(error);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = product.id;

        },
    },
})