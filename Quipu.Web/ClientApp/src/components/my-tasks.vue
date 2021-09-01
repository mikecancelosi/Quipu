<template>
    <q-header elevated>
        <q-toolbar>
            <q-btn flat
                   dense
                   round
                   @click="openNav"
                   aria-label="Menu"
                   v-show="!this.leftDrawerOpen"
                   icon="mdi-forwardburger" />

            <q-toolbar-title>
                My Tasks
            </q-toolbar-title>

            <List

        </q-toolbar>
    </q-header>


</template>


<script>
    import axios from 'axios'
    export default {
        name: "MyTasks",
        props: {
            leftDrawerOpen : Boolean,
        },
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
            },
            openNav() {
                this.$emit("open-nav");
            }
        },
        mounted() {
            this.getTasks();
        }
    }
</script>