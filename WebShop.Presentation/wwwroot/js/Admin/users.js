var app = new Vue({
    el: '#app',
    data: {
        username: ""        
    },
    mounted() {
        //TODO
    },
    methods: {
        createUser() {
            this.loading = true;
            axios.post('/users', { username: this.username })
                .then(result => {
                    console.log(result);
                    this.products = (result)
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }
}) 