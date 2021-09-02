<template>
    <h1 id="tableLabel">Projects</h1>
    <p v-if="projects.length === 0"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" >
        <thead>
            <tr>
                <th>Project Name</th>
                <th>Status</th>
                <th>Progress</th>
                <th>Priority</th>
            </tr>
        </thead>
        <tbody >
            <tr v-for="project of projects" v-bind:key="project" v-on:click ="navigateToProject(project)" >
                <td>{{ project.name }}</td>
                <td>{{ project.status ?? 'On Track' }}</td>
                <td>{{ getProjectProgess(project) }}</td>
                <td>{{ project.priority ?? 'Low' }}</td>
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
                axios.get('https://192.168.1.166:45458/api/Projects')
                    .then((response) => {
                        this.projects =  response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            getProjectProgess(project) {
                var taskSize = project.tasks.length;
                if (taskSize === 0) {
                    return '100%';
                }
                var completedTasks = 0;
                for (let i = 0; i < project.tasks.length; i++) {
                    if (project.tasks[i].completed) {
                        completedTasks++;
                    }
                }
                return completedTasks / taskSize;
            },
            navigateToProject(project) {
                console.log(project.id);
                this.$router.push("/Projects/"+project.id);
            }
        },
        mounted() {
            this.getProjects();
        }
    }
</script>