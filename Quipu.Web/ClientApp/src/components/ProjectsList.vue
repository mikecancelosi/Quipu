<template>
    <h1 id="tableLabel">Projects</h1>
    <p v-if="projects.length === 0"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" >
        <thead>
            <tr>
                <th>id</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="project of projects" v-bind:key="project">
                <td>{{ project.name }}</td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "ProjectsList",
        data() {
            return {
                projects: []
            }
        },
        methods: {
            getProjects() {
                axios.get('http://192.168.1.166:5000/api/Tasks')
                    .then((response) => {
                        this.projects =  response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getProjects();
        }
    }
</script>