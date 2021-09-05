<template>

    <q-header elevated="false" style="align-items:center;min-height:1px; height:100px; background-color:transparent;">
        <q-toolbar style="height:100%;">
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
                <h5>Projects</h5>
            </div>


        </q-toolbar>

    </q-header>
    <q-separator />

    <div id="contentContainer">
        <q-space />
        <div class="row">
            <q-btn icon="o_add" label="Add Project" push color="primary" />
            <q-space />
            <q-btn-dropdown color="primary" label="Sort" icon="o_filter_list" dense>
                <q-item clickable v-close-popup @click="onItemClick">
                    <q-item-section>
                        <q-item-label>None</q-item-label>
                    </q-item-section>
                </q-item>

                <q-item clickable v-close-popup @click="onItemClick">
                    <q-item-section>
                        <q-item-label>Due Date</q-item-label>
                    </q-item-section>
                </q-item>

                <q-item clickable v-close-popup @click="onItemClick">
                    <q-item-section>
                        <q-item-label>Alphabetical</q-item-label>
                    </q-item-section>
                </q-item>

            </q-btn-dropdown>

        </div>
        <q-space />
        <q-separator />

        <table class='table table-striped' aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Project Name</th>
                    <th>Status</th>
                    <th>Priority</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="project of projects" v-bind:key="project" v-on:click="navigateToProject(project)">
                    <td>{{ project.name }}</td>
                    <td>{{ project.status ?? 'On Track' }}</td>
                    <td>{{ project.priority ?? 'Low' }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<style scoped>
    .q-space{
        min-height:10px;
    }
    #contentContainer{
        padding:10px 20px;
    }
</style>

<script>
    import axios from 'axios'
    export default {
        name: "ProjectsList",
        props: {
            leftDrawerOpen:Boolean,
        },
        data() {
            return {
                projects: []
            }
        },
        methods: {
            getProjects() {
                axios.get('http://127.0.0.1:5000/api/Projects')
                    .then((response) => {
                        this.projects =  response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            navigateToProject(project) {
                this.$router.push("/Projects/"+project.id);
            }
        },
        mounted() {
            this.getProjects();
        }
    }
</script>