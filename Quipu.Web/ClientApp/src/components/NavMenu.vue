<template>
    <div>
        <q-list class="navigationdrawer">

            <div class="row" style="align-items:center">
                <q-item-label id="header" header>Quipu</q-item-label>
                <q-space />
                <div style="height:fit-content">

                    <q-btn flat
                           dense
                           round
                           @click="toggleLeftDrawerOpen()"
                           aria-label="Menu"
                           v-show="this.leftDrawerOpen"
                           icon="mdi-backburger" />
                </div>
            </div>
            <q-item dense clickable @click="this.$router.push('/Home')" disable>
                <q-item-section avatar>
                    <q-icon name="o_school" />
                </q-item-section>
                <q-item-section>
                    <q-item-label>Home</q-item-label>
                </q-item-section>
            </q-item>
            <q-item dense clickable :to="{name: 'MyTasksHome'}">
                <q-item-section avatar>
                    <q-icon name="o_code" />
                </q-item-section>
                <q-item-section>
                    <q-item-label>My Tasks</q-item-label>
                </q-item-section>
            </q-item>
            <q-item dense clickable @click="this.$router.push('/Inbox')" disable>
                <q-item-section avatar>
                    <q-icon name="o_chat" />
                </q-item-section>
                <q-item-section>
                    <q-item-label>Inbox</q-item-label>
                </q-item-section>
            </q-item>
            <q-item dense clickable @click="this.$router.push('/Projects')">
                <q-item-section avatar>
                    <q-icon name="o_forum" />
                </q-item-section>
                <q-item-section>
                    <q-item-label>Projects</q-item-label>
                </q-item-section>
            </q-item>
            <q-item dense clickable @click="this.$router.push('/Goals')" disable>
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

        <q-item style="margin-bottom:10px;">
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
            <q-item clickable
                    dense
                    @click="this.$router.push({name:'TeamOverview', params:{id: team.id}})">
                <q-item-section>
                    <div class="row" style="align-items:center">
                        <q-avatar color="teal-8" rounded size="10px" style="margin-right:10px" />
                        <a>{{team.name}}</a>
                        <q-space />
                        <q-btn round flat dense icon="o_more_vert" disable></q-btn>
                    </div>
                </q-item-section>
            </q-item>
        </q-list>
        <q-space style="min-height:20px;" />
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
    </div>
</template>


<script>
    import { mapGetters, mapActions } from 'vuex'
    import axios from 'axios'
    export default {
        name: "NavMenu",
        computed: mapGetters(['leftDrawerOpen']),
        data() {
            return {
                teams: []
            }
        },
        methods: {
            ...mapActions(['toggleLeftDrawerOpen']),
            getTeams() {
                axios.get('http://127.0.0.1:5000/api/Teams')
                    .then((response) => {
                        this.teams = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getTeams();
        }
    }
</script>

<style scoped>
    .navigationdrawer {
        padding: 10px 20px 20px 20px;
    }

    #header {
        font-size: 20px;
    }
</style>
