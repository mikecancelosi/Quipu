<template>

    <q-header style="align-items:center;min-height:1px; height:100px; background-color:transparent;">
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

        <q-table :rows="rows" 
                 :columns="columns"
                 :loading="loading"
                 @row-dblclick="navigateToProject"/>
    </div>
</template>

<style scoped>
    .q-space {
        min-height: 10px;
    }

    #contentContainer {
        padding: 10px 20px;
    }
</style>

<script>
    import axios from 'axios'
    import {  ref } from 'vue'
    export default {
        name: "ProjectsList",
        emits:["openNav"],
        props: {
            leftDrawerOpen: Boolean,
        },      
        data() {
            return {
                columns:
                    [
                        { name: "name", label: "Project Name", field: "name", align: 'left' },
                        { name: "status", label: "Status", field: "status", align: 'left' },
                        { name: "priority", label: "Priority", field: "priority", align: 'left' },
                    ],
                rows:[],                
                pagination: ref({
                    sortBy: 'desc',
                    descending: false,
                    page: 1,
                    rowsPerPage: 3,
                    rowsNumber: 10
                }),
                loading:true,
            }
        },
        methods: {
            getProjects() {
                axios.get('http://127.0.0.1:5000/api/Projects')
                    .then((response) => {
                        this.loading = false;
                        this.rows= response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            openNav() {
                this.$emit("open-nav");
            },
            navigateToProject(evt,row) {
                this.$router.push('/Projects/' + row.id);
            }
        },
        mounted() {
            this.getProjects();
        }
    }
</script>