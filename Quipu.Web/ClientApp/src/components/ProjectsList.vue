<template>    
    <q-header elevated>
        <pageheader  title="Projects"
                     icon="o_groups" />
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

        <q-table :rows="projects" 
                 :columns="columns"
                 :loading="loading"
                 @row-dblclick="navigateToProject"
                 id="projectTable"/>
    </div>
</template>

<style scoped>

    #contentContainer {
        padding: 20px;
    }

    #projectTable {
        margin-top:10px;
    }
</style>

<script>
    import { ref } from 'vue'
    import pageheader from './PageHeader'
    import { RepositoryFactory } from './../repositories/RepositoryFactory'
    const ProjectRepository = RepositoryFactory.get('projects')

    export default {
        name: "ProjectsList",
        components: {pageheader},   
        data() {
            return {
                columns:
                    [
                        { name: "name", label: "Project Name", field: "name", align: 'left' },
                        { name: "status", label: "Status", field: "status", align: 'left' },
                        { name: "priority", label: "Priority", field: "priority", align: 'left' },
                    ],
                projects: [],                
                pagination: ref({
                    sortBy: 'desc',
                    descending: false,
                    page: 1,
                    rowsPerPage: 10,
                    rowsNumber: 10
                }),
                loading:true,
            }
        },
        methods: {
            async fetch() {
                this.projects = (await ProjectRepository.get()).data;
                this.loading = false;
            },
            navigateToProject(evt,row) {
                this.$router.push('/Projects/' + row.id);
            }
        },
        mounted() {
            this.fetch();
        }
    }
</script>