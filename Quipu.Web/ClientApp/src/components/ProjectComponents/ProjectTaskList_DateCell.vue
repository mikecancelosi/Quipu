<template>
    <div class="cell" 
         @mouseenter="hover = true"
         @mouseleave="hover = false">
        <q-btn icon="o_calendar_today"
               round
               flat
               outline
               dense
               size="10px"
               v-if="hover &&
                     !showdropdown &&
                     newStartDate == '0001-01-01T00:00:00'"
               @click="showdropdown = true; "
               :style="{visibility: newStartDate == '0001-01-01T00:00:00'
                                                       ? 'visible'
                                                       : 'collapse'}">

        </q-btn>
        <div class="row" v-if="newStartDate != '0001-01-01T00:00:00'">
            
            <div>
                {{formattedDate}}
            </div>
            <q-space />
            <q-btn dense
                   round
                   flat
                   icon="o_close"
                   size="12px"                   
                   v-if="hover"
                   style="margin:0px 5px; min-height:0px;"
                   @click="cleardates();" />
        </div>
        <q-menu v-bind:model-value="showdropdown"
                v-bind:no-parent-event="true"
                @hide="showdropdown=false">
            <q-date range
                    v-model="dates"
                    @range-end="(range)=>assigndate(range)" />
        </q-menu>
    </div>
</template>

<style>
    .cell {
        height: 100%;
        width: 100%;
    }
</style>

<script>
    import {ref, computed} from 'vue'

    export default {
        name: "AssigneeCell",
        emits: ["update-task"],
        props: {
            startDate: {
                type: String,
                default: "0001-01-01T00:00:00",
            },
            endDate: {
                type: String,
                default: "0001-01-01T00:00:00",
            }
        },
        setup(props) {
            const hover = ref(false);
            const showdropdown = ref(false);
            const newStartDate = ref(props.startDate);
            const newEndDate = ref(props.endDate);

            const updatetask = () => {
                this.$emit("update-task", this.newStartdate, this.newEnddate);
            };

            const formattedDate = computed(() => {
                const sDate = new Date(newStartDate.value);
                const eDate = new Date(newEndDate.value);               
                return sDate.getMonth() + "/" + sDate.getDate() + "-" +
                    eDate.getMonth() + "/" + eDate.getDate();
            });


            const cleardates = () => {
                this.newstartDate = '0001-01-01T00:00:00';
                this.newDate = '0001-01-01T00:00:00';
                this.updatetask();
            };

            const assigndate = (range) => {
                this.newStartDate = new Date(range.from.month + " " + range.from.day + " " + range.from.year);
                this.newEndDate = new Date(range.to.month + " " + range.to.day + " " + range.to.year);
                this.updatetask();
            };

            return {
                hover, showdropdown, newStartDate, newEndDate,
                updatetask, formattedDate, cleardates, assigndate
            }

        },
        updated() {
            this.newstartDate = this.startDate;
            this.newendDate = this.endDate;
        }

    }
</script>