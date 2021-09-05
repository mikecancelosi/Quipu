<template>
    <q-header>
        <q-toolbar class="headingContainer">
            <q-btn flat
                   dense
                   round
                   @click="openNav"
                   aria-label="Menu"
                   v-show="!this.leftDrawerOpen"
                   icon="mdi-forwardburger" />

            <div>
                <q-toolbar-title>
                    My Tasks
                </q-toolbar-title>
               
                <q-list>

                    <q-list-item @click="this.$router.push('/MyTasks/List')"  class="subNav">
                        List
                    </q-list-item>

                    <q-list-item @click="this.$router.push('/MyTasks/Board')" class="subNav">
                        Board
                    </q-list-item>

                    <q-list-item @click="this.$router.push('/MyTasks/Calendar')" class="subNav">
                        Calendar
                    </q-list-item>

                </q-list>

            </div>

        </q-toolbar>
    </q-header>

    <q-page-container style="padding: 0 0 0 0">
      <router-view :tasks ="this.tasks"/>
    </q-page-container>


</template>

<style scoped>

    q-list-item:active{
        color:green;
    }
    q-page-container{
        padding:0 0 0 0;
        padding-top:0px;
    }
</style>


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
                axios.get('http://127.0.0.1:5000/api/Tasks')
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
            this.$router.push('/MyTasks/List')
            this.getTasks();
        }
    }
</script>