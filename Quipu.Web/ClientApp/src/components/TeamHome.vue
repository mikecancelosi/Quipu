<template>
    <q-header elevated>
        <q-toolbar class="headingContainer">
            <q-btn flat
                   dense
                   round
                   @click="openNav"
                   aria-label="Menu"
                   v-show="!this.leftDrawerOpen"
                   icon="mdi-forwardburger" />
            <div class="row"
                 style="align-items:center;">

                <q-btn icon="o_groups" size="24px" dense flat style="margin-right:15px; padding:0px;" />
                <a style="font-size:24px">
                    {{team.name}}
                </a>
                <q-btn flat round disable dense icon="o_expand_more" />
                <q-btn flat round disable dense icon="o_info" />
                <q-btn flat round disable dense icon="o_star_outline" />
                <q-btn flat rounded disable no-caps dense>
                    <q-icon left name="o_circle" size="10px" />
                    <div>Set status</div>
                </q-btn>
            </div>


        </q-toolbar>

        <q-tabs dense style="position:absolute; bottom:0;">

            <q-tab @click="this.$router.push('/Teams/'+ this.id +'/Overview')" >
                Overview
            </q-tab>

            <q-tab @click="this.$router.push('/Teams/'+ this.id +'/Projects')">
                Project List
            </q-tab>

            <q-tab disable>
                Board
            </q-tab>

            <q-tab disable>
                Timeline
            </q-tab>

            <q-tab disable>
                Calendar
            </q-tab>

            <q-tab disable>
                Dashboard
            </q-tab>

            <q-tab disable>
                Messages
            </q-tab>

            <q-tab disable>
                Files
            </q-tab>

        </q-tabs>
    </q-header>

    <q-page-container style="padding: 0 0 0 0">
        <router-view :team="this.team"/>
    </q-page-container>
</template>

<style>

    .q-tab {
        padding: 0px 10px;
        min-width:1px;
    }

    .q-header .q-tab__content {
        min-width: 1px;
    }

    
</style>

<script>
    import axios from 'axios'
    export default {
        name: 'TeamHome',
        props: {
            leftDrawerOpen: Boolean,
            id: Number
        },
        data() {
            return {                
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
            openNav() {
                this.$emit("open-nav");
            }
        },
        mounted() {
            this.getTeam();
            
        }

    }

</script>
