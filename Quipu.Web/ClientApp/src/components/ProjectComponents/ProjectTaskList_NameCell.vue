<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">

        <div class="row">
            <div>
                <q-btn dense
                       round
                       flat
                       v-bind:style="{color: completed ? 'green'                                                                                                           : 'white'}"
                       @click="completed = !completed; updatetask();"
                       class="checkbox"
                       icon="o_check_circle_outline" />
            </div>
            <q-input ref="nameinput"
                     debounce="1000"
                     dense
                     borderless
                     v-model="name"
                     @update:model-value="(val)=>tasklostfocus(true)"
                     @blur="(evt)=>tasklostfocus()" />
            <q-space />
            <q-btn label="Details"
                   icon-right="o_chevron_right"
                   flat
                   dense
                   no-caps
                   class="showonhover" 
                   @click="this.detailtask()"/>
        </div>
    </div>
</template>

<style scoped>
    .cell {
        width: 100%;
        height: 100%;
    }
    .checkbox:hover {
        color: green;
    }

    .list-row-noicon .tablecol .showonhover {
        visibility: hidden;
    }

    .list-row-noicon .tablecol:hover .showonhover {
        visibility: visible;
    }
    .q-input {
        padding: 5px;
        min-height: 0px;
        max-height: 30px;
        align-content: center;
        margin: 5px;
    }

        .q-input:hover {
            background-color: rgb(0,0,0,.3);
            outline: 1px solid rgb(255,255,255,.4);
            height: fit-content;
        }

    .q-field--focused {
        background-color: rgb(0,0,0,.3);
        outline: 1px solid rgb(255,255,255,.4);
        height: fit-content;
    }
</style>

<script>
    export default {
        name: "StatusCell",
        emits: ["update-task", "detail-task"],
        props: {
            task: {},
        },
        data() {
            return {
                hover: false,
                showdropdown: false,
                name: this.task.name,
                completed: this.task.completed
            }
        },
        methods: {
            updatetask() {
                this.$emit("update-task", this.name, this.completed);
            },

            tasklostfocus(focus) {
                if (name === '') {
                    this.getRows();
                } else {
                    this.updatetask();
                }
                if (focus) {
                    this.$nextTick(() => { this.$refs['nameinput'].focus(); });
                }
            },
            detailtask() {
                this.$emit("detail-task");
            },
        },
    }
</script>