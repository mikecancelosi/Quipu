<template>
    <q-page-container>
        <div id="previewcontainer">
            <div class="row">
                <q-btn label="Mark complete"
                       icon="o_done"
                       dense
                       outline />
                <q-space />

                <q-btn icon="o_attach_file" />
                <q-btn icon="o_format_list_bulleted" />
                <q-btn icon="o_more_vert" />
                <q-btn icon="mdi-forwardburger" />
            </div>
            <q-separator/>

            <div>{{task?.name ?? ""}}</div>

        </div>
    </q-page-container>
</template>

<style scoped>

    #previewcontainer{
        padding:20px;
    }

    .q-separator{
        margin:20px 0px;
    }
</style>

<script>
    export default {
        name: "TaskDetailPreview",
        emits: ["update-task"],
        props: {
            task: {},
        },
        data() {
            return {
                hover: false,
            }
        },
        methods: {
            updatetask() {
                this.$emit("update-task", this.newstartdate, this.newenddate);
            },
        },

    }
</script>