<template>
    <v-container fluid>
        <h1>My Tasksasksasksasksasksasksasksasksasksasksasksasks</h1>
    </v-container>
   


</template>


<script>
    import axios from 'axios'
    export default {
        name: "MyTasks",
        data() {
            return {
                tasks: []
            }
        },
        methods: {
            getTasks() {
                axios.get('https://192.168.1.166:45455/api/Tasks')
                    .then((response) => {
                        this.tasks =  response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }           
        },
        mounted() {
            this.getTasks();
        }
    }
</script>