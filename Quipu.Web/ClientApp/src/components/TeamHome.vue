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
                   {{team.name}}
                </q-toolbar-title>

                <q-list>

                    <q-list-item @click="this.$router.push('/Teams/Overview')">
                        Overview
                    </q-list-item>

                    <q-list-item>
                        List
                    </q-list-item>

                    <q-list-item>
                        Board
                    </q-list-item>

                    <q-list-item>
                        Timeline
                    </q-list-item>

                    <q-list-item>
                        Calendar
                    </q-list-item>

                    <q-list-item>
                        Dashboard
                    </q-list-item>

                    <q-list-item>
                        Messages
                    </q-list-item>

                    <q-list-item>
                        Files
                    </q-list-item>

                </q-list>

            </div>

        </q-toolbar>
    </q-header>

    <q-page-container style="padding: 0 0 0 0">
        <router-view :team="this.team"/>
    </q-page-container>
</template>


<script>
    import axios from 'axios'
    export default {
        name: 'TeamHome',
        props: ['id'],
        data() {
            return {
                leftDrawerOpen: true,
                team: {},

            }
        },
        methods: {
            getTeam() {
                axios.get('http://127.0.0.1:5000/api/Teams/' + this.id)
                    .then((response) => {
                        this.team = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
        },
        mounted() {
            this.getTeam();
            
        }

    }

</script>
