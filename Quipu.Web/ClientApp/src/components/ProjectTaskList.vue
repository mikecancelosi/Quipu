<template>
    <p>overview</p>
</template>

<script>
    import axios from 'axios'

    export default {
        name: "ProjectTaskList",
        props: {
            team: {},
        },
        data() {
            return {
                
            }
        },
        methods: {
            getProjects() {
                axios.get('http://127.0.0.1:5000/api/Projects')
                    .then((response) => {
                        this.loading = false;
                        this.rows = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            openNav() {
                this.$emit("open-nav");
            },
            navigateToProject(evt, row) {
                console.log(row.id);
                this.$router.push('/Projects/' + row.id);
            }
        },
        mounted() {
            this.getProjects();
        }
    }
</script>