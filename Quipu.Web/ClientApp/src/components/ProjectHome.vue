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
                    {{project.name}}
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

            <q-tab @click="this.$router.push('/Projects/'+ this.id +'/Overview')">
                Overview
            </q-tab>

            <q-tab @click="this.$router.push('/Projects/'+ this.id +'/TaskList')">
                Task List
            </q-tab>

            <q-tab disable>
                Task Board
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
        <router-view :project="this.project" />
    </q-page-container>



</template>

<style scoped>
    .headerText {
        text-align: left;
        margin: 0 0 0 20px
    }
</style>

<script>
    import axios from 'axios'
    export default {
        name: "ProjectHome",
        emits: ["openNav"],
        props: {
            id: String,
            leftDrawerOpen: Boolean,
        },
        data() {
            return {
                project: {},
            }
        },
        methods: {
            async getProject() {
                await axios.get('http://127.0.0.1:5000/api/Projects/' + this.id)
                    .then((response) => {
                        this.project = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            openNav() {
                this.$emit("open-nav");
            },
        },
        mounted() {
            this.getProject().then(() => {
                this.$router.push({ name: "ProjectOverview", params: { project: this.project } });
            })
        }
    }
</script>