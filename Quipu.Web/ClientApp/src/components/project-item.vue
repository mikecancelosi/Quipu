<template>
    <h1 class="headerText">{{project.name}}</h1>

    
   
</template>

<style scoped>
    .headerText {
        text-align:left;
        margin: 0 0 0 20px
        

    }
</style>

<script>
    import axios from 'axios'
    export default {
        name: "ProjectsList",
        props:['id'],
        data() {
            return {
                project: {},
            }
        },
        methods: {
            getProject() {
                axios.get('https://192.168.1.166:45455/api/Projects/' + this.id )
                    .then((response) => {
                        this.project = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
        },
        mounted() {
            this.getProject();
        }
    }
</script>