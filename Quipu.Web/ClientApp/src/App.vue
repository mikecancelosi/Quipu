<template>
    <q-layout view="lHh Lpr lFf">

        <q-drawer v-model="leftDrawerOpen"
                  show-if-above
                  bordered>
            <q-list class="navigationdrawer">

                <div class="row" style="align-items:center">
                    <q-item-label header>Quipu</q-item-label>
                    <q-space />
                    <div style="height:fit-content">

                        <q-btn flat
                               dense
                               round
                               @click="leftDrawerOpen = false"
                               aria-label="Menu"
                               v-show="leftDrawerOpen"
                               icon="mdi-backburger" />
                    </div>
                </div>
                <q-item dense clickable @click="this.$router.push('/Home')">
                    <q-item-section avatar>
                        <q-icon name="o_school" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>Home</q-item-label>
                    </q-item-section>
                </q-item>
                <q-item dense clickable :to="{name: 'MyTasks'}">
                    <q-item-section avatar>
                        <q-icon name="o_code" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>My Tasks</q-item-label>
                    </q-item-section>
                </q-item>
                <q-item dense clickable @click="this.$router.push('/Inbox')">
                    <q-item-section avatar>
                        <q-icon name="o_chat" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>Inbox</q-item-label>
                    </q-item-section>
                </q-item>
                <q-item dense clickable @click="this.$router.push('/Reporting')">
                    <q-item-section avatar>
                        <q-icon name="o_forum" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>Reporting</q-item-label>
                    </q-item-section>
                </q-item>
                <q-item dense clickable @click="this.$router.push('/Goals')">
                    <q-item-section avatar>
                        <q-icon name="o_rss_feed" />
                    </q-item-section>
                    <q-item-section>
                        <q-item-label>Goals</q-item-label>
                    </q-item-section>
                </q-item>
            </q-list>

            <q-separator />

            <q-expansion-item label="Favorites">

            </q-expansion-item>

            <q-separator />

            <q-item>
                <div class="row" style="align-items:center; width:100%">
                    <q-item-label>Teams</q-item-label>

                    <q-space />
                    <q-btn flat
                           dense
                           round
                           icon="o_add"
                           @click="this.$router.push('/Teams/Create')" />

                </div>
            </q-item>

            <q-list v-for="team in teams" :key="team">
                <q-item clickable @click="this.$router.push({name:'TeamOverview', params:{id: team.id}})">
                    <q-item-section>
                        <a>{{team.name}}</a>
                    </q-item-section>
                </q-item>
            </q-list>

            <q-separator />

            <q-item>
                <div class="row" style="align-items:center; width:100%">
                    <q-item-label>Projects</q-item-label>

                    <q-space />

                    <div>
                        <q-btn flat
                               dense
                               round
                               icon="o_add">
                            <q-menu>

                                <q-list id="create-proj-pop" dense>
                                    <a class="popup-heading">Create Project</a>
                                    <q-item clickable v-close-popup class="popup-item" disable>
                                        <q-item-section avatar>
                                            <q-icon name="o_dashboardpx" />
                                        </q-item-section>
                                        <q-item-section>Use a template</q-item-section>
                                    </q-item>
                                    <q-separator style="padding:0px;" />
                                    <q-item clickable v-close-popup class="popup-item" @click="this.$router.push('/Projects/Create')">
                                        <q-item-section avatar>
                                            <q-icon name="o_note_add" size="20px" />
                                        </q-item-section>
                                        <q-item-section>Blank Project</q-item-section>
                                    </q-item>
                                </q-list>
                            </q-menu>
                        </q-btn>
                    </div>
                </div>
            </q-item>
        </q-drawer>

        <q-page-container>
            <router-view @open-nav="openNav" :leftDrawerOpen="leftDrawerOpen" />
        </q-page-container>
    </q-layout>
</template>

<style scoped>
    .q-item__label--header {
        font-size: 20px;
    }

    .navigationdrawer {
        padding: 10px 20px 20px 20px;
    }

    .q-item__section--avatar {
        min-width: 0px;
    }

    #create-proj-pop {
        padding: 10px 0px 5px 0px;
        min-width: 200px;
    }

        #create-proj-pop > * {
            padding: 0px 10px 0px 10px;
            margin: 5px 0px;
        }

    .popup-heading {
        font-size: 12px;
        color: #888;
        font-weight: 600;
    }

    .popup-item {
    }
</style>

<style>
    h1 {
        font-size: 36px;
    }

    h2 {
        font-size: 24px;
    }
</style>

<script>
    import axios from 'axios'

    export default {
        name: 'LayoutDefault',
        data() {
            return {
                leftDrawerOpen: true,
                teams:[]
            }
        },
        methods: {
            openNav() {
                this.leftDrawerOpen = true;
            },
            getTeams() {
                axios.get('http://127.0.0.1:5000/api/Teams')
                    .then((response) => {
                        this.teams = response.data;
                        console.log(this.teams);
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.$router.push('/Home');
            this.getTeams();
        }

    }


</script>
