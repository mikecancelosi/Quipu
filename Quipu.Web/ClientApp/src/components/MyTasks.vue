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

            <div>
                <q-toolbar-title>
                    My Tasks
                </q-toolbar-title>
               
                <q-list>

                    <q-list-item @click="this.$router.push('/MyTasks/List')">
                        List
                    </q-list-item>

                    <q-list-item @click="this.$router.push('/MyTasks/Board')">
                        Board
                    </q-list-item>

                    <q-list-item @click="this.$router.push('/MyTasks/Calendar')">
                        Calendar
                    </q-list-item>

                </q-list>

            </div>

        </q-toolbar>
    </q-header>

    <q-page-container style="padding: 0 0 0 0">
      <router-view/>
    </q-page-container>


</template>

<style scoped>
    .q-toolbar{
        height:70px;
        background-color:transparent;
    }
    q-list-item{
        margin-right:20px;
    }
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
                axios.get('https://192.168.1.166:45458/api/Tasks')
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
            this.$router.push('/MyTasks/List')
        }
    }
</script>